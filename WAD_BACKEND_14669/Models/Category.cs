using System.ComponentModel.DataAnnotations;
using WAD_BACKEND_14669.Utils;

namespace WAD_BACKEND_14669.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MinWordsException(10, ErrorMessage = "Description should have at least 10 words.")]
        public string Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "AgeRestriction should be a non-negative integer")]
        public int? AgeRestriction { get; set; }
    }
}