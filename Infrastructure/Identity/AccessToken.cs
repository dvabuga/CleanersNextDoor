﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Identity
{
    public class AccessToken
    {
        public string token_type { get; set; }
        public string access_token { get; set; }
        public string expires_in { get; set; }
    }

}
