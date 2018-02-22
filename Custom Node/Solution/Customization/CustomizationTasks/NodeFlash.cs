using Thermo.SampleManager.Server.Workflow.Attributes;
using Thermo.SampleManager.Server.Workflow.Definition;

namespace Thermo.SampleManager.Server.Workflow.Nodes
{
    // Attribute to declare the Node Type, Name, Category, Icon, Description and Message Group
    [WorkflowNode("NODE_FLASH", "NodeFlashName", "NodeCategoryCustomName", "FLASH", "NodeFlashDescription", "CustomizationMessages")]

    // Attributes that control where the node can be placed and the Type
    [FollowsTag(WorkflowNodeTypeInternal.TagEntryPoint)]
    [FollowsTag(WorkflowNodeTypeInternal.TagConditionSet)]
    [FollowsTag(WorkflowNodeTypeInternal.TagData)]
    [FollowsTag(WorkflowNodeTypeInternal.TagRepeat)]
    [Tag(WorkflowNodeTypeInternal.TagOutput)]

    // Class Implementation
    public class FlashNode : Node
    {
        #region Constants

        #endregion

        // Formula Parameter Called Caption
        [FormulaParameter("NODE_FLASH_CAPTION", "NodeFlashMessageParamName", "NodeFlashMessageParamDescription", MessageGroup = "CustomizationMessages")]
        public string Caption
        {
            get
            {
                string parameterBagValue = this.GetParameterBagValue<string>("NODE_FLASH_CAPTION");
                if (string.IsNullOrEmpty(parameterBagValue))
                    return "";
                return parameterBagValue;
            }
            set
            {
                this.SetParameterBagValue("NODE_FLASH_CAPTION", (object)value);
            }
        }


        #region Constructor

        public FlashNode(WorkflowNodeInternal node) : base(node)
        {
        }

        #endregion

        #region Perform

        /// <summary>
        /// Performs the workflow node and its child nodes
        /// </summary>
        public override bool PerformNode()
        {
            this.TracePerformNode();
            string formulaText = this.GetFormulaText(this.Caption);
            this.Library.Utils.FlashMessage(formulaText, "Hello");
            this.TraceInfo("Trace Node Flash", (object)formulaText);
            return true;
        }

        #endregion

        #region Auto Naming

        /// <summary>
        /// Auto Node naming.
        /// </summary>
        public override string AutoName()
        {
            return string.Format("Flash message - {0}", this.GetFormulaText(this.Caption));
        }

        #endregion
    }
}