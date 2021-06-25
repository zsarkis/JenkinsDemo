// Powered by Infostretch 

pipeline {
    agent any
    
    stages{
	    stage ('Checkout') {
	        steps{
	            git url: 'https://github.com/zsarkis/JenkinsDemo.git', branch: 'main'
	        }
        }
	    stage ('Build') {
 			// Shell build step
 			steps{
                sh """ 
                dotnet build jenkinsDemo.sln
                dotnet test --logger:"nunit;LogFileName=TestResults.xml" jenkinsDemo.sln 
                """
 			}
 			
	        post {
                always {
                    nunit testResultsPattern: 'JenkinsDemoTests/TestResults/*.xml'
                }
            }
	    }
	}
}
