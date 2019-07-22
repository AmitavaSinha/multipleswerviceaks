namespace LoginAPIService.Models.DB
{
    public partial class UserLogin
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string IsActive { get; set; }
        public string ContactNumber { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public string UserPassword { get; set; }
    }
}
