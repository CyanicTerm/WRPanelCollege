using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WRPanel.Models.ViewModels
{
    public class StorageVM
    {
        public Storage Storage { get; set; }
        public IEnumerable<SelectListItem> ClientList { get; set; }
    }
}
