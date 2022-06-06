﻿using System;
using System.Threading.Tasks;



using Grpc.Net.Client;

namespace SnakeConsoleClient
{
    public static class Program
    {

        public static async Task Main()
        {
            SessionWrapper sessionWrapper;

            using var channel = GrpcChannel.ForAddress("http://localhost:5000");
            {
                await using var session = new SessionWrapper(channel);
                sessionWrapper = session;

                try
                {
                    await session.SecondPlayer.Login("Danila");
                    await Task.Delay(1000);
                    await session.FirstPlayer.Login("Valera");
                    await Task.Delay(1000);

                    await session.FirstPlayer.SendResult(10);
                    await Task.Delay(1000);
                    await session.SecondPlayer.SendResult(5);
                    await Task.Delay(1000);


                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            foreach (var reply in sessionWrapper.FirstPlayer.Replies)
                Console.WriteLine(reply);

            Console.WriteLine();

            foreach (var reply in sessionWrapper.SecondPlayer.Replies)
                Console.WriteLine(reply);

            Console.ReadKey();
        }
    }
}
