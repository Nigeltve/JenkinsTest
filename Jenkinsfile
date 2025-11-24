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
				dotnet build
			}
		}

		stage('Test') {

			steps {
				echo 'Running tests...'
				dotnet test
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