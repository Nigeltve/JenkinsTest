pipeline {
	agent {
		any
		tools {
			dotnet 'DOTNET_SDK_10'
		}
	}

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
				sh 'dotnet build'
			}
		}

		stage('Test') {
			steps {
				echo 'Running tests...'
				sh 'dotnet test'
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