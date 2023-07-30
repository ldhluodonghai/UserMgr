using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMgr.Domain.Uilities;
using UserMgr.Domain.ValueObject;

namespace UserMgr.Domain.Entities
{
    public class User : IAggregateRootcs
    {
        public Guid Id { get; set; }
        public PhoneNumber PhoneNumber { get; private set; }
        private string? passwordHash;
        public UserAccessFail AccessFail { get;private set; }
        private User() { }
        public User(PhoneNumber phoneNumber)
        {
            Id = Guid.NewGuid();
            PhoneNumber = phoneNumber;
            this.AccessFail = new UserAccessFail(this);
        }
        public bool HasPassword()
        {
            return !string.IsNullOrEmpty(passwordHash);
        }
        public void ChangePassword(string value)//修改密码
        {
            if (value.Length <= 3)
            {
                throw new ArgumentException("密码长度不能小于3");
            }
            passwordHash = MD5Helper.MD5Cryptography(value);
        }
        //检查密码是否正确
        public bool CheckPassword(string value)
        {
            return passwordHash == MD5Helper.MD5Cryptography(value);

        }
        public void ChangePhoeNumber(PhoneNumber number)
        {
            PhoneNumber = number;   
        }

    }
     
}
