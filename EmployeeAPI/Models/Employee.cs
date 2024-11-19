using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Models
{
    public class Employee
    {
        /* Represents The Unique Identifier For Each Employee.
           A GUID (Globally Unique Identifier) Is Used To Ensure That Each ID Is Unique Across The System.*/

        [Key]
        public Guid Id { get; set; }

        /* This Field Is Mandatory, And It Has A Maximum Length Of 25 Characters To Ensure Consistency.
           Following Validation Ensures That The Name Cannot Be Left Empty And Is Within The Allowed Length.*/

        [Required(ErrorMessage = "Name Is Required.")]
        [StringLength(25, ErrorMessage = "Name Should Not Be Longer Than 25 Characters.")]
        public string Name { get; set; }

        /*This Field Is Mandatory And Must Be In A Valid Email Format(Ex. user@example.com).
          This Validation Attributes Ensure Proper Formatting And Prevent Empty Values.*/

        [Required(ErrorMessage = "Email Is Required.")]
        [EmailAddress(ErrorMessage = "Please Enter A Valid Email Address (Ex., user@example.com).")]
        public string Email { get; set; }
    }
}
