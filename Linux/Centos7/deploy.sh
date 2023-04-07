#! /bin/bash
pip install rancher-python-client
# Write Registry Object

#Prepare the Images Directory and K3s Binary
sudo mkdir -p /var/lib/rancher/k3s/agent/images/
sudo cp ./k3s-airgap-images-$ARCH.tar /var/lib/rancher/k3s/agent/images/


# Install K3s
curl -sfL https://get.k3s.io | sh -


wget https://get.helm.sh/helm-v3.6.0-linux-amd64.tar.gz
tar xvf helm-v3.6.0-linux-amd64.tar.gz 
sudo mv linux-amd64/helm /usr/local/bin
rm helm-v3.6.0-linux-amd64.tar.gz
rm -rf linux-amd64