using System;
using System.Collections.Generic;
using Exiled.API.Features;

namespace AdminRoleSelect
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;
        public override string Author { get; } = "Galaxy119 & PaRRoT_tm";
        public override string Name { get; } = "AdminRoleSelect";
        public override string Prefix { get; } = "AdminRoleSelect";
        public override Version Version { get; } = new Version(1, 0, 3);
        public override Version RequiredExiledVersion { get; } = new Version(3, 7, 2);
        public EventHandlers EventHandlers { get; private set; }

        public Dictionary<Player, RoleType> SelectedRoles { get; } = new Dictionary<Player, RoleType>();
        public Random Rng = new Random();

        public override void OnEnabled()
        {
            Instance = this;
            EventHandlers = new EventHandlers(this);

            Exiled.Events.Handlers.Player.ChangingRole += EventHandlers.OnChangingRole;
            Exiled.Events.Handlers.Server.RoundStarted += EventHandlers.OnRoundStarted;
            Exiled.Events.Handlers.Server.WaitingForPlayers += EventHandlers.OnWaitingForPlayers;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.ChangingRole -= EventHandlers.OnChangingRole;
            Exiled.Events.Handlers.Server.RoundStarted -= EventHandlers.OnRoundStarted;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= EventHandlers.OnWaitingForPlayers;
            EventHandlers = null;

            base.OnDisabled();
        }
    }
}