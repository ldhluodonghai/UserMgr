using System;

namespace UserMgr.Domain.Entities
{
    public record UserAccessFail
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public User User { get; init; }
        private bool lockOut;//是否锁定
        public DateTime? LockoutEnd { get; private set; }
        public int AccessFailedCount { get; private set; }
        public UserAccessFail() { }
        public UserAccessFail(User user)
        {
            Id = Guid.NewGuid();
            User = user;
         
        }
        //重置登陆失败信息
        public void Reset()
        {
            lockOut = false;
            LockoutEnd = null;
            AccessFailedCount = 0;
        }
        //是否锁定
        public bool IsLockOut()
        {
            if (lockOut)
            {
                if(LockoutEnd>= DateTime.Now)
                {
                    return true;
                }
                else
                {
                    AccessFailedCount = 0;
                    LockoutEnd = null;
                    return false;
                }
            }
            else
            {
                return true;
            }
           
        }
        //处理一次“登陆失败'
        public void Fail()
        {
            AccessFailedCount++;
            if(AccessFailedCount>=3) 
            {
                lockOut=true;
                LockoutEnd = DateTime.Now.AddMinutes(5);

            }
        }
    }
}