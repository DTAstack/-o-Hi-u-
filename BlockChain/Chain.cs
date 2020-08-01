
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BlockChain
{
    public class Chain
    {
        public Chain()
        {
            Blocks = new List<Block>{ 
                new Block
                {
                    Index = 0,
                    Transactions = new Transaction[0],
                    LastBlockHash = string.Empty,
                    Proof = 1,
                    TimeStamp = DateTime.UtcNow
                }
            };
            CurrentTransactions = new List<Transaction>();
            
        }