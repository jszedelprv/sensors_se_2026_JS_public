using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyKai.Gesture.Test
{
    public partial class GestureCursorDataTest
    {
        // Arrange/Act delegates
        private delegate void CursorSetDelegate<T>(T pInitVal1, T pInitVal2);
        private delegate (T, T) CursorGetDelegate<T>();

        private enum ignore_T { zero_value = 0 };

        private void Cursor2DTest_ParametersCorrect<T_Init, T>( CursorSetDelegate<T_Init> pArrangeFunc, CursorSetDelegate<T> pActFunc,
                                                                (T_Init v1, T_Init v2) pInitValues, (T v1, T v2)[] pTestValues )
        {
            // Arrange
            if (pArrangeFunc != null)
                pArrangeFunc(pInitValues.v1, pInitValues.v2);

            // Act 
            try
            {
                foreach ((T testVal1, T testVal2) item in pTestValues)
                    pActFunc(item.testVal1, item.testVal2);
            }

            // Assert
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        private void Cursor2DTest_ParametersOutOfRange<T_Arrange, T, E>( CursorSetDelegate<T_Arrange> pArrangeFunc, CursorSetDelegate<T> pActFunc,
                                                                      (T_Arrange v1, T_Arrange v2) pInitValues, (T v1, T v2)[] pTestValues ) where E : Exception
        {
            // Arrange
            if (pArrangeFunc != null)
                pArrangeFunc(pInitValues.v1, pInitValues.v2);

            // Act and assert 
            foreach ((T testVal1, T testVal2) item in pTestValues)
            {
                Assert.ThrowsException<E>(() => pActFunc(item.testVal1, item.testVal2));
            }

        }

        private void Cursor2DTest_CheckCalculations<T_Arrange, T_Pass, T_Res>( CursorSetDelegate<T_Arrange> pArrangeFunc, CursorGetDelegate<T_Res> pGetFunc,
                                                                               CursorSetDelegate<T_Pass> pActFunc, (T_Arrange v1, T_Arrange v2) pInitValues, 
                                                                               (T_Pass v1, T_Pass v2)[] pTestValues, (T_Res v1, T_Res v2)[] pResValues )
        {
            // Arrange
            int i = 0;

            if (pArrangeFunc != null)
                pArrangeFunc(pInitValues.v1, pInitValues.v2);

            // Act and assert 
            foreach ((T_Pass testVal1, T_Pass testVal2) item in pTestValues)
            {
                pActFunc(item.testVal1, item.testVal2);
                (T_Res v1, T_Res v2) correctValues = pGetFunc();
                Assert.IsTrue(correctValues.v1.Equals(pResValues[i].v1) && correctValues.v2.Equals(pResValues[i].v2));
                i++;
            }
        }
    }
}
