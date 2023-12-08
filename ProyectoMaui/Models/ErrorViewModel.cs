using System;
namespace ProyectoMaui.Models
{
	public class ErrorViewModel
	{
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

