using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiskey.Model
{
    /// <summary>
    /// QuoteModel is simple POCO, which can be used to serialize/deserialize JSON data received from web service.
    /// This model can be replaced with any other model provided the JSON is matched with it and respective UI changes are made.
    /// </summary>
    public class QuotesModel
    {
        public int Id { get; set; }
        public string Quote { get; set; }
        public string QuoteBy { get; set; }
    }
}
