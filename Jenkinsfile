pipeline {
	agent {
		docker {
			image 'mcr.microsoft.com/dotnet/sdk:10.0'
			args '-v /var/run/docker.sock:/var/run/docker.sock'
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
				sh 'dotnet restore'
				sh 'dotnet build --no-restore'
			}
		}

		stage('Test') {
			steps {
				echo 'Running tests...'
				sh 'dotnet test --no-restore'
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