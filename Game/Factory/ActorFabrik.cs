using SFML.System;
using SFML.Graphics;
using Game.Core;
using Game.Units;
using Game.Interfaces;

namespace Game.Factory
{
    public static class ActorFabrik
    {
        public static T CreateActor<T>(this GameLoop game, Shape shape, IntRect rect, Texture texture, Vector2f position = new Vector2f()) where T:Actor,new()
        {
            T t = CreateActor_Internal<T>(shape, rect, texture, position);
            if (t == null)
                return null;

            RegisterActor(game, t);
            return t;
        }

        private static void RegisterActor(GameLoop game, Actor t)
        {
            if (t is IUpdatable)
                game.RegisterActor(t as IUpdatable);
            if (t is IDrawable)
                game.RegisterDrawableActor(t);
        }

        private static T CreateActor_Internal<T>(Shape shape, IntRect rect, Texture texture, Vector2f position) where T : Actor, new()
        {
            ActorArgs args;
            args.Position = position;
            args.Rect = rect;
            args.Shape = shape;
            args.texture = texture;
            T t = new T();
            t.PostCreate(args);
            return t;
        }
    }
}
