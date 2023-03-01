
namespace my_expenses.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Icon { get; set; } = "";

        [Column(TypeName = "nvarchar(20)")]
        public string Type { get; set; } = "Expense";

    }
}
