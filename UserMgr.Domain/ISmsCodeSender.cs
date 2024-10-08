﻿using System.Threading.Tasks;
using UserMgr.Domain.ValueObject;
using Users.Domain;

namespace Users.Domain
{
    public interface ISmsCodeSender
    {
        Task SendCodeAsync(PhoneNumber phoneNumber,string code);
    }
}
