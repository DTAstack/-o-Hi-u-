
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BlockChain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BlockChainNode.Controllers
{
    [Produces("application/json")]
    [Route("api/Node")]
    public class NodeController : Controller
    {
        private readonly List<Node> _nodes;
        private readonly Chain _chain;
        private readonly BlockChainOptions _options;

        public NodeController(List<Node> nodes, IOptions<BlockChainOptions> options, Chain chain)
        {
            _nodes = nodes;
            _chain = chain;
            _options = options.Value;
        }

        [HttpGet("status")]
        public IActionResult Status()
        {