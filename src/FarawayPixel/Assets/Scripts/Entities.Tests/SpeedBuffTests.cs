using Faraway.Pixel.Entities.Buffs;
using NSubstitute;
using NUnit.Framework;

namespace Faraway.Pixel.Entities.Tests
{
    /// <summary>
    /// Represents the speed buff tests.
    /// </summary>
    public class SpeedBuffTests
    {
        private const float SpeedChangeFactor1 = 1f;
        private const float SpeedChangeFactor2 = 2f;
        private const float BuffDuration1 = 10f;
        private const float BuffDuration2 = 1f;
        private const float Epsilon = 0.001f;

        private LocomotionParameters locomotionParameters;
        private ITimeProvider timeProvider;
        private BuffCollection buffCollection;

        [SetUp]
        public void Initialize()
        {
            locomotionParameters = new LocomotionParameters();
            timeProvider = Substitute.For<ITimeProvider>();
            timeProvider.Now.Returns(0);
            buffCollection = new BuffCollection(timeProvider);
        }

        [Test]
        public void SpeedBuff_Single_ChangesSpeedFactor()
        {
            var speedBuff = CreateSpeedBuff(SpeedChangeFactor1, BuffDuration1);
            buffCollection.AddBuff(speedBuff);
            timeProvider.Now.Returns(BuffDuration1 - Epsilon);
            buffCollection.Update();
            
            Assert.AreEqual(SpeedChangeFactor1, locomotionParameters.SpeedFactor);
        }
        
        [Test]
        public void SpeedBuff_Single_Expires()
        {
            var speedBuff = CreateSpeedBuff(SpeedChangeFactor1, BuffDuration1);
            buffCollection.AddBuff(speedBuff);
            timeProvider.Now.Returns(BuffDuration1 + Epsilon);
            buffCollection.Update();
            
            Assert.AreEqual(LocomotionParameters.DefaultSpeedFactor, locomotionParameters.SpeedFactor);
        }
        
        [Test]
        public void SpeedBuff_Combine_UseLatestValue()
        {
            var speedBuff1 = CreateSpeedBuff(SpeedChangeFactor1, BuffDuration1);
            buffCollection.AddBuff(speedBuff1);
            timeProvider.Now.Returns( Epsilon);
            buffCollection.Update();
            
            var speedBuff2 = CreateSpeedBuff(SpeedChangeFactor2, BuffDuration2);
            buffCollection.AddBuff(speedBuff2);
            timeProvider.Now.Returns(timeProvider.Now + BuffDuration2 - Epsilon);
            buffCollection.Update();
            
            Assert.AreEqual(SpeedChangeFactor2, locomotionParameters.SpeedFactor);
        }
        
        [Test]
        public void SpeedBuff_Combine_UseLatestDuration()
        {
            var speedBuff1 = CreateSpeedBuff(SpeedChangeFactor1, BuffDuration1);
            buffCollection.AddBuff(speedBuff1);
            timeProvider.Now.Returns( Epsilon);
            buffCollection.Update();
            
            var speedBuff2 = CreateSpeedBuff(SpeedChangeFactor2, BuffDuration2);
            buffCollection.AddBuff(speedBuff2);
            timeProvider.Now.Returns(timeProvider.Now + BuffDuration2 + Epsilon);
            buffCollection.Update();
            
            Assert.AreEqual(LocomotionParameters.DefaultSpeedFactor, locomotionParameters.SpeedFactor);
        }

        private SpeedBuff CreateSpeedBuff(float speedFactor, float duration)
        {
            var data = new SpeedBuffData(speedFactor, duration);
            var buff = new SpeedBuff(data, locomotionParameters);
            return buff;
        }
    }
}
