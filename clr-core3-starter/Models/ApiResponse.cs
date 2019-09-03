using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace clr_core3_starter.Models
{
    public class ApiResponse
    {
        public bool Status { get; set; }
        public Item Item { get; set; }
        public ModelStateDictionary ModelState { get; set; }
    }
}
