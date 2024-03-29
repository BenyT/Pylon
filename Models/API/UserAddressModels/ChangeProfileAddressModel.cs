﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aiursoft.Pylon.Models.API.UserAddressModels
{
    public class ChangeProfileAddressModel : UserOperationAddressModel
    {
        [Required]
        [MaxLength(20)]
        public string NewNickName { get; set; }
        [Obsolete]
        [Required]
        public int NewIconId { get; set; }
        [Required]
        public string NewIconFilePathName { get; set; }
        [MaxLength(80)]
        public string NewBio { get; set; }
    }
}
