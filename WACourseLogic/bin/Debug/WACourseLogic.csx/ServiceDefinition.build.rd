<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="WACourseLogic" generation="1" functional="0" release="0" Id="0ff165b6-db4f-475c-bad7-b4aa19cf2666" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="WACourseLogicGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="CourseLogicWeb:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/WACourseLogic/WACourseLogicGroup/LB:CourseLogicWeb:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="CourseLogicWeb:?IsSimulationEnvironment?" defaultValue="">
          <maps>
            <mapMoniker name="/WACourseLogic/WACourseLogicGroup/MapCourseLogicWeb:?IsSimulationEnvironment?" />
          </maps>
        </aCS>
        <aCS name="CourseLogicWeb:?RoleHostDebugger?" defaultValue="">
          <maps>
            <mapMoniker name="/WACourseLogic/WACourseLogicGroup/MapCourseLogicWeb:?RoleHostDebugger?" />
          </maps>
        </aCS>
        <aCS name="CourseLogicWeb:?StartupTaskDebugger?" defaultValue="">
          <maps>
            <mapMoniker name="/WACourseLogic/WACourseLogicGroup/MapCourseLogicWeb:?StartupTaskDebugger?" />
          </maps>
        </aCS>
        <aCS name="CourseLogicWebInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/WACourseLogic/WACourseLogicGroup/MapCourseLogicWebInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:CourseLogicWeb:Endpoint1">
          <toPorts>
            <inPortMoniker name="/WACourseLogic/WACourseLogicGroup/CourseLogicWeb/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapCourseLogicWeb:?IsSimulationEnvironment?" kind="Identity">
          <setting>
            <aCSMoniker name="/WACourseLogic/WACourseLogicGroup/CourseLogicWeb/?IsSimulationEnvironment?" />
          </setting>
        </map>
        <map name="MapCourseLogicWeb:?RoleHostDebugger?" kind="Identity">
          <setting>
            <aCSMoniker name="/WACourseLogic/WACourseLogicGroup/CourseLogicWeb/?RoleHostDebugger?" />
          </setting>
        </map>
        <map name="MapCourseLogicWeb:?StartupTaskDebugger?" kind="Identity">
          <setting>
            <aCSMoniker name="/WACourseLogic/WACourseLogicGroup/CourseLogicWeb/?StartupTaskDebugger?" />
          </setting>
        </map>
        <map name="MapCourseLogicWebInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/WACourseLogic/WACourseLogicGroup/CourseLogicWebInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="CourseLogicWeb" generation="1" functional="0" release="0" software="D:\Official\Projects\Hoang\Client Code\CourseLogic_Unbind_MVC_12-05-2011\WACourseLogic\bin\Debug\WACourseLogic.csx\roles\CourseLogicWeb" entryPoint="base\x86\WaHostBootstrapper.exe" parameters="base\x86\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="?IsSimulationEnvironment?" defaultValue="" />
              <aCS name="?RoleHostDebugger?" defaultValue="" />
              <aCS name="?StartupTaskDebugger?" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;CourseLogicWeb&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;CourseLogicWeb&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/WACourseLogic/WACourseLogicGroup/CourseLogicWebInstances" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyID name="CourseLogicWebInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="2113f321-ae66-4dbe-af2a-9582bfe8db7f" ref="Microsoft.RedDog.Contract\ServiceContract\WACourseLogicContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="239bc3a2-4168-42be-9f0e-6f1183f55e0d" ref="Microsoft.RedDog.Contract\Interface\CourseLogicWeb:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/WACourseLogic/WACourseLogicGroup/CourseLogicWeb:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>