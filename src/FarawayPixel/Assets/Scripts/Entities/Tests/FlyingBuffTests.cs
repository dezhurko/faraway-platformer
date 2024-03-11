using Faraway.Pixel.Entities.Buffs;
using Faraway.Pixel.Entities.Locomotion;
using NSubstitute;
using NUnit.Framework;

namespace Faraway.Pixel.Entities.Tests
{
    public class FlyingBuffTests
    {
        private Player player;
        private ITimeProvider timeProvider;
        private BuffCollection buffCollection;
        private ILocomotionActor locomotionActor;
        
        private const float BuffDuration1 = 10f;
        private const float BuffDuration2 = 1f;
        private const float Epsilon = 0.001f;

        [SetUp]
        public void Initialize()
        {
            player = new Player();
            player.SetLocomotion(new DefaultLocomotionSystem(locomotionActor, player));
            locomotionActor = Substitute.For<ILocomotionActor>();
            timeProvider = Substitute.For<ITimeProvider>();
            timeProvider.Now.Returns(0);
            buffCollection = new BuffCollection(timeProvider);
        }
        
        [Test]
        public void FlyingBuff_Single_ChangesLocomotion()
        {
            var buff = CreateFlyingBuff(BuffDuration1);
            buffCollection.AddBuff(buff);
            timeProvider.Now.Returns(BuffDuration1 - Epsilon);
            buffCollection.Update();
            
            Assert.AreEqual(typeof(FlyingLocomotionSystem), player.Locomotion.GetType());
        }
        
        [Test]
        public void FlyingBuff_Single_Expires()
        {
            var buff = CreateFlyingBuff(BuffDuration1);
            buffCollection.AddBuff(buff);
            timeProvider.Now.Returns(BuffDuration1 + Epsilon);
            buffCollection.Update();
            
            Assert.AreEqual(typeof(DefaultLocomotionSystem), player.Locomotion.GetType());
        }
        
        [Test]
        public void FlyingBuff_Combine_UseLatestEndTime1()
        {
            var buff1 = CreateFlyingBuff(BuffDuration1);
            var buff2 = CreateFlyingBuff(BuffDuration2);
            buffCollection.AddBuff(buff1);
            buffCollection.AddBuff(buff2);
            timeProvider.Now.Returns(BuffDuration1 - Epsilon);
            buffCollection.Update();
            
            Assert.AreEqual(typeof(FlyingLocomotionSystem), player.Locomotion.GetType());
        }
        
        [Test]
        public void FlyingBuff_Combine_UseLatestEndTime2()
        {
            var buff1 = CreateFlyingBuff(BuffDuration1);
            var buff2 = CreateFlyingBuff(BuffDuration2);
            buffCollection.AddBuff(buff1);
            timeProvider.Now.Returns(BuffDuration1 - Epsilon);
            buffCollection.AddBuff(buff2);
            timeProvider.Now.Returns(timeProvider.Now + BuffDuration2 - Epsilon);
            buffCollection.Update();
            
            Assert.AreEqual(typeof(FlyingLocomotionSystem), player.Locomotion.GetType());
        }

        private FlyingBuff CreateFlyingBuff(float duration)
        {
            return new FlyingBuff(new FlyingBuffData(duration), locomotionActor, player);
        }
    }
}