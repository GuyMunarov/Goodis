namespace Goodis.Dtos
{
    public class UserToReturnDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
    }
}
