﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace NJ_Service
{
    public class HttpMethodOverrideHandler: DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Headers.TryGetValues("X-HTTP-Method-Override", out var methodOverrideHeader))
            {
                request.Method = new HttpMethod(methodOverrideHeader.First());
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}