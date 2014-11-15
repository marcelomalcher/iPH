using System;
using System.Collections.Generic;
using System.Text;

using iPH.Commons.Functions;
using iPH.Commons.User.Role;

namespace iPH.Commons.Manager
{
    public class FunctionsManager
    {
        #region Members
        private List<BaseFunction> myFunctions;
        private List<RoleFunction> myRoleFunctionList;
        #endregion

        #region Ctor
        public FunctionsManager()
        {
            this.myFunctions = new List<BaseFunction>();
            this.LoadFunctions();

            this.myRoleFunctionList = new List<RoleFunction>();
            this.LoadRoleFunctions();
        }
        #endregion

        #region Props

        public int Count
        {
            get
            {
                return this.myFunctions.Count;
            }
        }

        public List<BaseFunction> List
        {
            get
            {
                return this.myFunctions;
            }
        }

        public BaseFunction this[int index]
        {
            get
            {
                return this.myFunctions[index];
            }
        }

        #endregion

        #region Load Methods
        private void LoadFunctions()
        {
            if (this.myFunctions == null)
                return;
            //Loading functions
            this.myFunctions.Add(ClassroomPersistenceFunction.Intance);
            this.myFunctions.Add(ContributionFunction.Intance);
            this.myFunctions.Add(ParticipantsManagerFunction.Intance);
            this.myFunctions.Add(PresentationEditionFunction.Intance);
            this.myFunctions.Add(PresentationSendFunction.Intance);
            this.myFunctions.Add(SubmitModificationsFunction.Intance);
        }

        private void LoadRoleFunctions()
        {
            if (this.myRoleFunctionList == null)
                return;
            //Loading Role Functions
            //Offline
            this.myRoleFunctionList.Add(new RoleFunction(Offline.Instance, ClassroomPersistenceFunction.Intance));
            this.myRoleFunctionList.Add(new RoleFunction(Offline.Instance, PresentationEditionFunction.Intance));
            this.myRoleFunctionList.Add(new RoleFunction(Offline.Instance, ContributionFunction.Intance));
            //Master
            this.myRoleFunctionList.Add(new RoleFunction(Master.Instance, ClassroomPersistenceFunction.Intance));
            this.myRoleFunctionList.Add(new RoleFunction(Master.Instance, PresentationEditionFunction.Intance));
            this.myRoleFunctionList.Add(new RoleFunction(Master.Instance, ContributionFunction.Intance));
            this.myRoleFunctionList.Add(new RoleFunction(Master.Instance, PresentationSendFunction.Intance));           
            this.myRoleFunctionList.Add(new RoleFunction(Master.Instance, ParticipantsManagerFunction.Intance));
            //Contribuitor
            this.myRoleFunctionList.Add(new RoleFunction(Contribuitor.Instance, ClassroomPersistenceFunction.Intance));
            this.myRoleFunctionList.Add(new RoleFunction(Contribuitor.Instance, ContributionFunction.Intance));
            this.myRoleFunctionList.Add(new RoleFunction(Contribuitor.Instance, SubmitModificationsFunction.Intance));
            //Viewer
        }
        #endregion

        #region Methods
        public bool HasFunction(BaseRole role, BaseFunction function)
        {
            foreach (RoleFunction roleFunction in this.myRoleFunctionList)
            {
                if (roleFunction.IsEqual(role, function))
                    return true;
            }
            return false;
        }
        #endregion
    }

    class RoleFunction
    {
        #region Member
        private BaseRole myRole;
        private BaseFunction myFunction;
        #endregion

        #region Ctor
        public RoleFunction(BaseRole role, BaseFunction function)
        {
            this.myRole = role;
            this.myFunction = function;
        }
        #endregion

        #region Properties
        public BaseRole Role
        {
            get
            {
                return this.myRole;
            }
        }

        public BaseFunction Function
        {
            get
            {
                return this.myFunction;
            }
        }
        #endregion

        #region Method
        public bool IsEqual(BaseRole role, BaseFunction function)
        {
            if ((this.myRole.GetType() != role.GetType()) || (this.myFunction.GetType() != function.GetType()))
                return false;
            return true;
        }
        #endregion
    }

}
