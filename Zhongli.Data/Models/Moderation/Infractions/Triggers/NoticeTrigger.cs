namespace Zhongli.Data.Models.Moderation.Infractions.Triggers
{
    public class NoticeTrigger : Trigger
    {
        public NoticeTrigger(uint amount, TriggerSource source, TriggerMode mode) : base(amount, source, mode) { }
    }
}