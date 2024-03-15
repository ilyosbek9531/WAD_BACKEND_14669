using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WAD_BACKEND_14669.Utils;

namespace WAD_BACKEND_14669.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MinWordsException(10, ErrorMessage = "Description should have at least 10 words.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "ReleaseDate is required")]
        [ReleaseDateValidation(ErrorMessage = "ReleaseDate should be before today")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Duration should be a non-negative integer")]
        public int Duration { get; set; }

        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}