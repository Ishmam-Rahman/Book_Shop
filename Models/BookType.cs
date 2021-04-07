using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStroe.Models
{
    public class BookType
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string TypeName { get; set; }

        [JsonIgnore]
        public ICollection<BookModel> BookModel { get; set; }
    }
}
