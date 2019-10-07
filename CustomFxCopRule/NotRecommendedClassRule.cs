using Microsoft.FxCop.Sdk;

namespace CustomFxCopRule
{
    internal class NotRecommendedClassRule : BaseFxCopRule
    {
        public NotRecommendedClassRule() : base("NotRecommendedClassRule")
        {
        }

        public override TargetVisibilities TargetVisibility
        {
            get
            {
                return TargetVisibilities.All;
            }
        }

        public override ProblemCollection Check(Member member)
        {
            Method methd = member as Method;
            if (methd != null)
            {
                VisitStatements(methd.Body.Statements);
            }

            return this.Problems;
        }
        public override void VisitAssignmentStatement(AssignmentStatement assignment)
        {
            Expression target = assignment.Target;
            if (target != null)
            {
                if (IsDerivedFromClass(target.Type, "System.Security.Cryptography.MD5"))
                {
                    Resolution resolution = GetResolution("'System.Security.Cryptography.MD5'");
                    var problem = new Problem(resolution, target.SourceContext);
                    Problems.Add(problem);
                }
            }
        }        private bool IsDerivedFromClass(TypeNode typeNode, string classFullName)
        {
            if (typeNode == null)
            {
                return false;
            }

            bool isDerived = typeNode.FullName == classFullName;

            return isDerived || IsDerivedFromClass(typeNode.BaseType, classFullName);
        }    }
}
