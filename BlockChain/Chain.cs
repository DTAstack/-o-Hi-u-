
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