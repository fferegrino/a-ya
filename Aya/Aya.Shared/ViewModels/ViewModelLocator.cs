﻿using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aya.ViewModels
{
    public class ViewModelLocator
    {
        public HubViewModel HubVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HubViewModel>();
            }
        }

        public CommonPhrasesViewModel CommonPhrasesVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CommonPhrasesViewModel>();
            }
        }


        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<HubViewModel>();
            SimpleIoc.Default.Register<CommonPhrasesViewModel>();
        }
    }
}
