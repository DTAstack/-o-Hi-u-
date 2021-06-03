
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BlockChain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BlockChainNode.Controllers
{
    [Produces("application/json")]
    [Route("api/Mine")]
    public class MineController : Controller
    {
        private readonly Chain _chain;
        private readonly List<Node> _nodes;
        private BlockChainOptions _options;

        public MineController(Chain chain, List<Node> nodes, IOptions<BlockChainOptions> options)
        {
            _chain = chain;
            _nodes = nodes;
            _options = options.Value;
        }

        [HttpGet]
        public IActionResult LastBlock()
        {
            return Ok(_chain.Blocks.Last());