pipeline {
	agent any
	tools {
		dotnetsdk 'Dotnet_10'
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
				sh 'dotnet --version'
			}
		}

		stage('Test') {
			steps {
				echo 'Running tests...'
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