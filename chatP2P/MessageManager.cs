﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Diagnostics;
using encryptingArariba;
using Microsoft.VisualBasic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Configuration;

namespace chatP2P
{
    class MessageManager
    {
        const int HANDSHAKECOUNT = 3;

        const string MY_IP_ADRESSE = "10.5.53.39";
        static private string IP_ADDRESS = "10.5.43.52";
        static private int PORT = 13;

        static private MessageManager singleton = null;
        private TcpClient client = null;
        private TcpListener listener = null;
        private int currentStep;
        private bool isListner;

        public void DefineAsListner() { isListner = true; }
        public void DefineAsClient() { isListner = false; }

        private MessageManager()
        {
            listener = new(new IPEndPoint(IPAddress.Any, PORT));
            currentStep = 0;
            /*Connect();*/

        }

        public static MessageManager GetInstance()
        {
            if (singleton == null)
            {
                singleton = new MessageManager();
            }
            return singleton;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task<bool> ConnectAsListner()

        {
            listener.Start();
            while (true)
            {
                try
                {
                    client = await listener.AcceptTcpClientAsync();
                    Debug.WriteLine(client);
                    await using NetworkStream stream = client.GetStream();
                    bool done = await singleton.HandShake();
                    Debug.WriteLine(done);
                    return done;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

        }
        private async Task<bool> ConnectAsClient(IPEndPoint ipEndPoint)
        {
            client = new TcpClient();
            await client.ConnectAsync(ipEndPoint);
            //await using NetworkStream stream = client.GetStream();

            return await singleton.HandShake();
        }

        public async Task<bool> Connect(string ipAdress, int port)
        {
            IPEndPoint ipEndPoint = new(IPAddress.Parse(ipAdress), port);
            return isListner ? await ConnectAsListner() : await ConnectAsClient(ipEndPoint);
        }

        public async Task<bool> Connect()
        {
            IPEndPoint ipEndPoint = null;
            return isListner ? await ConnectAsListner() : await ConnectAsClient(ipEndPoint);
        }

        async public Task<bool> HandShake()
        {
            currentStep = 0;
            return (isListner) ? await HandShakeListner() : await HandShakeClient();
        }

        async private Task<bool> HandShakeListner()
        {
            while (currentStep < HANDSHAKECOUNT)
            {
                switch (currentStep)
                {
                    case 0: // Send Helo
                        {
                            bool bRetValue = await InternalSendStringAsync("Helo");
                            if (bRetValue == false)
                            {
                                return false;
                            }
                            // Next step
                            ++currentStep;
                            break;
                        }
                    case 1: // Wait for OK
                        {
                            byte[] buffer = await InternalReceiveAsync();
                            if (BitConverter.ToString(buffer) != "OK")
                            {
                                return false;
                            }
                            // Next step
                            ++currentStep;
                            break;
                        }
                    case 3: // Envoi du nonce
                        {
                            // Next step
                            ++currentStep;
                            break;
                        }
                }

            }
            /*
            try
            {
                HandShake handShake = new HandShake(MY_IP_ADRESSE, Encryptor.GenNonce, Encryptor.Key, false);
                await singleton.SendMessage("hello");

                var resp = await singleton.ReceiveMessage();
                Debug.WriteLine(resp);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
            */
            // Done
            return true;
        }
        async private Task<bool> HandShakeClient()
        {
            while (currentStep < HANDSHAKECOUNT)
            {
                switch (currentStep)
                {
                    case 0: // Send Helo
                        {
                            byte[] buffer = await InternalReceiveAsync();
                            if (BitConverter.ToString(buffer) != "Helo")
                            {
                                return false;
                            }
                            // Next step
                            ++currentStep;
                            break;
                        }
                    case 1: // Wait for OK
                        {
                            bool bRetValue = await InternalSendStringAsync("OK");
                            if (bRetValue == false)
                            {
                                return false;
                            }
                            // Next step
                            ++currentStep;
                            break; 
                        }
                }
            }
            return true;
        }

        private async Task<byte[]> InternalReceiveAsync()
        {
            byte[] buffer = new byte[1024];
            try
            {
                await using NetworkStream stream = client.GetStream();
                int received = stream.Read(buffer);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("InternalReceiveAsync  - Exception:" + ex.Message);
            }
            return buffer;
        }

        private async Task<bool> InternalSendStringAsync(string msg)
        {
            return await InternalSendAsync(Encoding.UTF8.GetBytes(msg));
        }

        private async Task<bool> InternalSendAsync(byte[] buffer)
        {
            try
            {
                Debug.WriteLine("SendMessage {0}", BitConverter.ToString(buffer));
                await using NetworkStream stream = client.GetStream();
                await stream.WriteAsync(buffer);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("InternalReceiveAsync  - Exception:" + ex.Message);
                return false;
            }
            // Done
            return true;
        }

        // Convert an object to a byte array
        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        // Convert a byte array to an Object
        public static Object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }
    }
}
