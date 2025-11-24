pipeline {
	agent any

	stages {
		stage('Checkout') {
			steps {
				echo 'Checking out code from repository...'
				checkout scm
			}
		}

		stage('Build') {
			steps {
				echo 'Building the project...'
				withDotNet('DOTNET_SDK') {
					sh 'dotnet build'
				}
			}
		}

		stage('Test') {
			steps {
				echo 'Running tests...'
				withDotNet('DOTNET_SDK') {
					sh 'dotnet test'
				}
			}
		}
	}

	post {
		always {
			echo 'Cleaning up workspace...'
			cleanWs()
		}
	}
}