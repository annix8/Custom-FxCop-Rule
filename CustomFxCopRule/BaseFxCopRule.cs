using Microsoft.FxCop.Sdk;

namespace CustomFxCopRule
{
    internal abstract class BaseFxCopRule : BaseIntrospectionRule
    {
        protected BaseFxCopRule(string ruleName)
            : base(ruleName, "CustomFxCopRule.RuleMetadata", typeof(BaseFxCopRule).Assembly)
        { }
    }
}
