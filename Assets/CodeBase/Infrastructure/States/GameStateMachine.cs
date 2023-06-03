using CodeBase.Infrastructure.Logic;
using CodeBase.Services;
using CodeBase.Services.Factory;
using CodeBase.Services.GameObserver;
using CodeBase.Services.LogicFactory;
using CodeBase.Services.StaticData;
using System;
using System.Collections.Generic;

namespace CodeBase.Infrastructure.States
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IExitable> _states;
        private IExitable _activeState;

        public GameStateMachine(SceneLoader sceneLoader, LoadCurtain loadCurtain, AllServices services)
        {
            _states = new Dictionary<Type, IExitable>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, loadCurtain,
                    services.Single<IGameFactory>(),
                    services.Single<IStaticDataService>(),
                    services.Single<IGameObserverService>(),
                    services.Single<ILogicFactory>()),

                [typeof(LoopState)] = new LoopState(),
            };
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        private TState ChangeState<TState>() where TState : class, IExitable
        {
            _activeState?.Exit();
            TState state = _states[typeof(TState)] as TState;
            _activeState = state;
            return state;
        }
    }
}