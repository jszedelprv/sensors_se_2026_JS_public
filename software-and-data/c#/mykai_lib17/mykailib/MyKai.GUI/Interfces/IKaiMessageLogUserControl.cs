// Project: MyKai
// Created Date: 2023-10-01
// Author: jsoftz
// (C) copyright 2023-2025 jsoftz
// This is the interface for the KaiMessageLogUserControl

using MyKai.Manager;

namespace MyKai.GUI
{
    public interface IKaiMessageLogUserControl
    {
        IKaiEventLogger KaiEventLogger { get; }
        void AddInitialLogMessage();
        void ActivateConnectionWait();
    }
}