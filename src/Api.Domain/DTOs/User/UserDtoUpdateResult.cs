using System;

namespace Api.Domain.DTOs.User
{
    public class UserDtoUpdateResult : UserDtoCreateResult
    {
        public DateTime UpdateAt { get; set; }
    }
}
