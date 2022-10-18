using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

/************************************************************************************
* Autor：xuliangxing
* Email：907562392@qq.com
* WeChart：xuliangxing
* Version：V1.0.0.0
* CreateTime：2018/4/8 13:36:40
* Description：
* Company：
* Copyright © 2018  All Rights Reserved
************************************************************************************/
namespace RestFulService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ActivityInfoQueryServices : IActivityInfoQuery
    {
        private List<ActivityInfo> ActivityList = new List<ActivityInfo>();
        private List<UserInfo> UserInfoList = new List<UserInfo>();
        /// <summary>
        /// 生成一些测试数据
        /// </summary>
        public ActivityInfoQueryServices()
        {
            ActivityList.Add(new ActivityInfo() { ID = 1, Name = "张三" });
            ActivityList.Add(new ActivityInfo() { ID = 2, Name = "李四" });
            ActivityList.Add(new ActivityInfo() { ID = 3, Name = "王二麻子" });
            UserInfoList.Add(new UserInfo() { ID = 1, Password = "123" });

        }
        /// <summary>
        /// 实现Getinfo方法，返回活动的信息
        /// </summary>
        /// <param name="name">为空则在message中返回所有activityname，不为空返回特定activityInfo</param>
        /// <returns></returns>
        public string GetInfo()
        {
            //返回所有活动名，和id
            string ActivitySum = "";
            foreach(ActivityInfo temp in ActivityList)
            {
                ActivitySum += "\\" + temp.Name + " " + temp.ID;
            }
            ActivitySum += "\\";
            return ActivitySum;
        }
        /// <summary>
        /// 实现CreateInfo方法，返回活动的信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public ActivityInfo CreateInfo(ActivityInfo info)
        {
            info.ID = ActivityList.Last().ID+1;
            ActivityList.Add(info);
            return new ActivityInfo(StateCodeEnum.CreateSuccess);
        }



        /// <summary>
        /// 根据info修改某活动，返回修改结果（含于User中）
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public ActivityInfo ModifyInfo(ActivityInfo info)
        {
            if (info.ID == 0)
            {
                info.ID = ActivityList.Last().ID + 1;
                ActivityList.Add(info);
                return new ActivityInfo(StateCodeEnum.CreateSuccess);
            }
            foreach(ActivityInfo temp in ActivityList)
            {
                if(info.ID == temp.ID)
                {

                    PropertyInfo[] propertys = info.GetType().GetProperties();

                    foreach (PropertyInfo pinfo in propertys)
                    {
                        if (pinfo.GetValue(info).ToString() != ""&& pinfo.GetValue(info).ToString() != "0" && pinfo.GetValue(info).ToString() != "NULL")
                        {
                            pinfo.SetValue(temp, pinfo.GetValue(info));
                        }
                    }
                    return new ActivityInfo(StateCodeEnum.ModifySuccess);
                }
            }
            
            return new ActivityInfo(StateCodeEnum.Failed);
        }



        /// <summary>
        /// 删除某个活动，返回删除结果
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public ActivityInfo DeleteInfo(ActivityInfo info)
        {
            foreach( ActivityInfo temp in ActivityList)
            {
                if (temp.ID == info.ID)
                {
                    ActivityList.Remove(temp);
                    return new ActivityInfo(StateCodeEnum.DeleteSuccess);
                }
            }
            return new ActivityInfo(StateCodeEnum.Failed);
        }

        public UserInfo UserLogin(UserInfo userInfo)
        {
            return UserInfoList.FirstOrDefault(n => n.ID == userInfo.ID && n.Password == userInfo.Password);
        }

        public ActivityInfo GetSelectedInfo(ActivityInfo activityInfo)
        {
            return ActivityList.FirstOrDefault(n => n.ID == activityInfo.ID);
        }
    }
}
