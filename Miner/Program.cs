
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