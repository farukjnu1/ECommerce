using ECommerce.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.ViewModels
{
    public class TransferVM
    {
        public int TransferId { get; set; }

        public string? Description { get; set; }

        public bool? IsApprove { get; set; }
        public List<TransferDetailVM> TransferDetails { get; set; } = new List<TransferDetailVM>();
        public List<SelectListItem> Products { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> SourceStores { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> DestinationStores { get; set; } = new List<SelectListItem>();
        public int? ProductId { get; set; }

        public int? Quantity { get; set; }

        public int? SourceStore { get; set; }

        public int? DestinationStore { get; set; }
        public string? SourceStoreName { get; set; }

        public string? DestinationStoreName { get; set; }
        public string? ProductName { get; set; }
        public class TransferDetailVM
        {
            public int Id { get; set; }

            public int? TransferId { get; set; }

            public int? ProductId { get; set; }

            public int? Quantity { get; set; }

            public int? SourceStore { get; set; }

            public int? DestinationStore { get; set; }
            public string? SourceStoreName { get; set; }

            public string? DestinationStoreName { get; set; }
            public string? ProductName { get; set; }

        }
    }
}
