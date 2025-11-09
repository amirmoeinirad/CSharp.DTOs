
// Amir Moeini Rad
// September 2025


// Main Concept: DTO (Data Transfer Object) Pattern
// DTOs are simple objects that are used to transfer data between layers or systems.


namespace DTO
{
    // (1) Domain Model/Entity (represents internal business logic or data.)
    // This class is mapped to a database table in a real application.
    public class User
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? PasswordHash { get; set; } // Sensitive data, should not be exposed in DTO.
    }


    // -------------------------------------------------


    // (2) DTO (used to transfer safe, necessary data only)
    public class UserDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
    }


    // -------------------------------------------------


    // (3) Service that converts domain models to DTOs.
    // In real applications, consider using libraries like 'AutoMapper' for complex mappings.
    // Notice: PasswordHash is not exposed in the DTO
    public static class UserMapper
    {
        public static UserDto MapToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FullName = user.FullName
            };
        }
    }

    
    // -------------------------------------------------


    // (4) Example usage
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------");
            Console.WriteLine("DTOs in C#.NET.");
            Console.WriteLine("---------------\n");


            // Domain object from database
            // In a real application, this would come from a database or business logic layer.
            User user = new()
            {
                Id = 1,
                FullName = "Alice Johnson",
                PasswordHash = "xyz123hashedpassword"
            };


            // Convert the domain object/entity/model to the DTO
            UserDto userDto = UserMapper.MapToDto(user);


            // Display DTO data
            Console.WriteLine("User DTO:");
            Console.WriteLine($"Id: {userDto.Id}");
            Console.WriteLine($"FullName: {userDto.FullName}");


            Console.WriteLine("\nDone.");
        }
    }
}
