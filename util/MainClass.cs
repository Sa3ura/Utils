﻿//Copyright 2023 Silver Wolf,All Rights Reserved.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled;
using Exiled.API;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using Exiled.Events;

namespace UtilPlugin
{
    public class PluginConfig : IConfig
    {
        [Description("设置是否启用插件")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }
        [Description("是否启用系统核弹")]
        public bool AutoCleanupEnabled { get; set; } = true;
        [Description("每次自动清理的时间（以秒为单位）")]
        public float Cleanuptime { get; set; } = 500;
        [Description("是否启用系统核弹")]
        public bool SystemWarheadEnabled { get; set; } = true;
        [Description("系统核弹触发时间")]
        public float SystemWarheadTime { get; set; } = 1200;
        [Description("系统核弹触发时公告")]
        public string SystemWarheadBroadcast { get; set; } = "注意，系统核弹已经启动";
        [Description("回合结束后是否自动引爆核弹")]
        public bool DetonateOnRoundEnded { get; set; } = false;
        [Description("启用管理员预留位")]
        public bool ReserveSlotEnabled { get; set; } = false;
        [Description("管理员预留位数量")]
        public int Slots { get; set; } = 5;
        [Description("预留位踢出理由")]
        public string ReserveSlotKickReason { get; set; } = "服务器已满人";
        [Description("允许投票提前开启系统核")]
        public bool AllowVoteSystemWarhead { get; set; } = true;
        [Description("投票时长")]
        public int VotingTime { get; set; } = 120;
    }
    public class UtilPlugin : Plugin<PluginConfig>
    {
        public override void OnEnabled()
        {
            base.OnEnabled();
            EventHandler.Register(Config.AutoCleanupEnabled);
            ReserveSlot.Register(Config.ReserveSlotEnabled);
            SystemWarhead.Register();
        }
        public override string Author => "Silver Wolf";
        public override string Name => "UtilPlugin";
        public override Version Version => new Version(1,3,0);
        public static UtilPlugin Instance { get; private set; }
        public UtilPlugin()
        {
            Instance = this;
        }
    }
}
