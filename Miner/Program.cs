
﻿using System;
using System.IO;
using System.Net.Http;
using BlockChain;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddUserSecrets("Miner")
                    .Build();

                var nodeId = config["NodeId"];
                var mineUrl = new Uri(args[0]);

                var httpClient = new HttpClient();
