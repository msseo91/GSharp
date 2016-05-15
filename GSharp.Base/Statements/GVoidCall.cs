﻿using System;
using System.Linq;
using GSharp.Base.Cores;
using GSharp.Extension;
using GSharp.Base.Scopes;

namespace GSharp.Base.Statements
{
    [Serializable]
    public class GVoidCall : GStatement, ICall
    {
        #region 객체
        private GFunction targetFunction;
        private GCommand targetCommand;
        public GObject[] targetArguments;
        #endregion

        #region 생성자
        public GVoidCall(GFunction valueFunction)
        {
            targetFunction = valueFunction;
        }

        public GVoidCall(GFunction valueFunction, GObject[] valueArguments) : this(valueFunction)
        {
            targetArguments = valueArguments;
        }

        public GVoidCall(GCommand valueCommand)
        {
            targetCommand = valueCommand;
        }

        public GVoidCall(GCommand valueCommand, GObject[] valueArguments) : this(valueCommand)
        {
            targetArguments = valueArguments;
        }
        #endregion

        public override string ToSource()
        {
            string valueTarget = targetFunction == null ? targetCommand.FullName : targetFunction.FunctionName;

            if (targetArguments == null)
            {
                return string.Format
                (
                    "{0}();",
                    valueTarget
                );
            }
            else
            {
                var argumentStrings = targetArguments.Select(element => element.ToSource());

                return string.Format
                (
                    "{0}({1});",
                    valueTarget,
                    string.Join(", ", argumentStrings)
                );
            }
        }
    }
}