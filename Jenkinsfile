pipeline {
	agent any
	tools {
		dotnetsdk 'dotnet_10'
	}

	environment {
		DOTNET_SYSTEM_GLOBALIZATION_INVARIANT = '1'
	}

	stages {
		stage('Checkout') {
			steps {
				echo 'Checking out code from repository...'
				sh 'dotnet --version'
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