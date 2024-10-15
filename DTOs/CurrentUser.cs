namespace DTOs
{
  public struct CurrentUser
  {
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }

    public CurrentUser(string id, string firstName, string lastName, string email, string role)
    {
      Id = id;
      FirstName = firstName;
      LastName = lastName;
      Email = email;
      Role = role;
    }
    
    public override string ToString()
    {
      return $"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, Email: {Email}, Role: {Role}";
    }
  }
}