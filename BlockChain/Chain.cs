
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

        public List<Block> Blocks { get; set; }
        public List<Transaction> CurrentTransactions { get; set; }
        

        public static bool ValidateProof(Block lastBlock, int proof)
        {
            var hashString = Hash((long)lastBlock.Proof * proof);
            return hashString.EndsWith("00000=");
        }

        public static string Hash(long hashInt)
        {
            var sha = new SHA256Managed();
            var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(hashInt.ToString()));
            return Convert.ToBase64String(hash);
        }

        public static string Hash(Block block)
        {
            var sha = new SHA256Managed();
            var blockString = block.LastBlockHash + block.TimeStamp.ToString("O") + block.Index + block.Proof;
            blockString = block.Transactions.Aggregate(blockString, (current, blockTransaction) => current + blockTransaction.Amount.ToString() + blockTransaction.From.ToString() + blockTransaction.To.ToString());
            var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(blockString));