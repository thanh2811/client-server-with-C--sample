﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientWebService.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://wwww.hocvienmang.com/", ConfigurationName="ServiceReference1.SampleWebServicesSoap")]
    public interface SampleWebServicesSoap {
        
        // CODEGEN: Generating message contract since element name UserName from namespace http://wwww.hocvienmang.com/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://wwww.hocvienmang.com/Hello", ReplyAction="*")]
        ClientWebService.ServiceReference1.HelloResponse Hello(ClientWebService.ServiceReference1.HelloRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wwww.hocvienmang.com/GetLocalDateTime", ReplyAction="*")]
        System.DateTime GetLocalDateTime();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wwww.hocvienmang.com/GetLocalDateTimeTicks", ReplyAction="*")]
        long GetLocalDateTimeTicks();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wwww.hocvienmang.com/GetUtcDateTime", ReplyAction="*")]
        System.DateTime GetUtcDateTime();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wwww.hocvienmang.com/GetUtcDateTimeTicks", ReplyAction="*")]
        long GetUtcDateTimeTicks();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wwww.hocvienmang.com/GetLocalDiffernceTicks", ReplyAction="*")]
        long GetLocalDiffernceTicks(long ClientLocalDateTimeTicks);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wwww.hocvienmang.com/GetUtcDiffernceTicks", ReplyAction="*")]
        long GetUtcDiffernceTicks(long ClientUtcDateTimeTicks);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wwww.hocvienmang.com/GetLocalDateTimeAndDiffernceTicks", ReplyAction="*")]
        System.DateTime GetLocalDateTimeAndDiffernceTicks(long ClientLocalDateTimeTicks, ref long DiffernceTicks);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wwww.hocvienmang.com/GetUtcDateTimeAndDiffernceTicks", ReplyAction="*")]
        System.DateTime GetUtcDateTimeAndDiffernceTicks(long ClientUtcDateTimeTicks, ref long DiffernceTicks);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Hello", Namespace="http://wwww.hocvienmang.com/", Order=0)]
        public ClientWebService.ServiceReference1.HelloRequestBody Body;
        
        public HelloRequest() {
        }
        
        public HelloRequest(ClientWebService.ServiceReference1.HelloRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://wwww.hocvienmang.com/")]
    public partial class HelloRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string UserName;
        
        public HelloRequestBody() {
        }
        
        public HelloRequestBody(string UserName) {
            this.UserName = UserName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloResponse", Namespace="http://wwww.hocvienmang.com/", Order=0)]
        public ClientWebService.ServiceReference1.HelloResponseBody Body;
        
        public HelloResponse() {
        }
        
        public HelloResponse(ClientWebService.ServiceReference1.HelloResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://wwww.hocvienmang.com/")]
    public partial class HelloResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloResult;
        
        public HelloResponseBody() {
        }
        
        public HelloResponseBody(string HelloResult) {
            this.HelloResult = HelloResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SampleWebServicesSoapChannel : ClientWebService.ServiceReference1.SampleWebServicesSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SampleWebServicesSoapClient : System.ServiceModel.ClientBase<ClientWebService.ServiceReference1.SampleWebServicesSoap>, ClientWebService.ServiceReference1.SampleWebServicesSoap {
        
        public SampleWebServicesSoapClient() {
        }
        
        public SampleWebServicesSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SampleWebServicesSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SampleWebServicesSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SampleWebServicesSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ClientWebService.ServiceReference1.HelloResponse ClientWebService.ServiceReference1.SampleWebServicesSoap.Hello(ClientWebService.ServiceReference1.HelloRequest request) {
            return base.Channel.Hello(request);
        }
        
        public string Hello(string UserName) {
            ClientWebService.ServiceReference1.HelloRequest inValue = new ClientWebService.ServiceReference1.HelloRequest();
            inValue.Body = new ClientWebService.ServiceReference1.HelloRequestBody();
            inValue.Body.UserName = UserName;
            ClientWebService.ServiceReference1.HelloResponse retVal = ((ClientWebService.ServiceReference1.SampleWebServicesSoap)(this)).Hello(inValue);
            return retVal.Body.HelloResult;
        }
        
        public System.DateTime GetLocalDateTime() {
            return base.Channel.GetLocalDateTime();
        }
        
        public long GetLocalDateTimeTicks() {
            return base.Channel.GetLocalDateTimeTicks();
        }
        
        public System.DateTime GetUtcDateTime() {
            return base.Channel.GetUtcDateTime();
        }
        
        public long GetUtcDateTimeTicks() {
            return base.Channel.GetUtcDateTimeTicks();
        }
        
        public long GetLocalDiffernceTicks(long ClientLocalDateTimeTicks) {
            return base.Channel.GetLocalDiffernceTicks(ClientLocalDateTimeTicks);
        }
        
        public long GetUtcDiffernceTicks(long ClientUtcDateTimeTicks) {
            return base.Channel.GetUtcDiffernceTicks(ClientUtcDateTimeTicks);
        }
        
        public System.DateTime GetLocalDateTimeAndDiffernceTicks(long ClientLocalDateTimeTicks, ref long DiffernceTicks) {
            return base.Channel.GetLocalDateTimeAndDiffernceTicks(ClientLocalDateTimeTicks, ref DiffernceTicks);
        }
        
        public System.DateTime GetUtcDateTimeAndDiffernceTicks(long ClientUtcDateTimeTicks, ref long DiffernceTicks) {
            return base.Channel.GetUtcDateTimeAndDiffernceTicks(ClientUtcDateTimeTicks, ref DiffernceTicks);
        }
    }
}